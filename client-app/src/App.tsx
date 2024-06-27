import { useEffect, useState } from 'react'
import './App.css'
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';
/* import { ducks } from './Demo'
import DuckItme from './DuckItme' */

function App() {
  const [activities, setActivities] = useState([]);
  useEffect(() => {
    axios.get('http://localhost:5000/api/activities').then(response => {
      setActivities(response.data)
    })
  }, [])
  return (
    <div>
      <Header as='h1' icon='users' content='Reactivities' />
      <List animated='true'>
        {activities.map((activity: any) => (
          <List.Item key={activity.id}>{activity.title}</List.Item>
        ))}
      </List>
    </div>
    /*  <div>
       <h1>Reactivities</h1>
       {ducks.map(duck => (
         <DuckItme key={duck.name} duck={duck}></DuckItme>
       ))}
     </div> */

  )
}

export default App
