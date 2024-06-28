import { useEffect, useState } from 'react'
import axios from 'axios';
import { Container } from 'semantic-ui-react';
import { Activity } from '../models/activity';
import NavBar from './NaxBar';
import { v4 as uuid } from "uuid";
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
/* import { ducks } from './Demo'
import DuckItme from './DuckItme' */

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);

  useEffect(() => {
    axios.get<Activity[]>('http://localhost:5000/api/activities').then(response => {
      setActivities(response.data)
    })
  }, [])

  function handleSelectedActivity(id: string) {
    setSelectedActivity(activities.find(x => x.id === id));
  }
  function handleCancleSelectActivity() {
    setSelectedActivity(undefined);
  }

  function handleFormOpen(id?: string) {
    id ? handleSelectedActivity(id) : handleCancleSelectActivity();
    setEditMode(true);
  }

  function handleFormClose() {
    setEditMode(false);
  }

  function handleCreateOrEditActivity(activity: Activity) {
    activity.id ? setActivities([...activities.filter(x => x.id !== activity.id), activity]) :
      setActivities([...activities, { ...activity, id: uuid() }]);
    setEditMode(false);
    setSelectedActivity(activity);
  }

  function handleDeleteActivity(id: string) {
    setActivities([...activities.filter(x => x.id !== id)]);
  }


  return (
    <>
      <NavBar formOpen={handleFormOpen} />
      <Container style={{ marginTop: '7em' }} >
        <ActivityDashboard
          selectActivity={handleSelectedActivity}
          selectedActivity={selectedActivity}
          cancleSelectActivity={handleCancleSelectActivity}
          activities={activities}
          editMode={editMode}
          openForm={handleFormOpen}
          closeForm={handleFormClose}
          createOrEdit={handleCreateOrEditActivity}
          deleteActivity={handleDeleteActivity}
        />
      </Container>
    </>
    /*  <div>
       <h1>Reactivities</h1>
       {ducks.map(duck => (
         <DuckItme key={duck.name} duck={duck}></DuckItme>
       ))}
     </div> */

  )
}

export default App
