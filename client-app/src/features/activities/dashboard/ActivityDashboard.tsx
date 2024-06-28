import React from "react";
import { Grid, List } from "semantic-ui-react";
import { Activity } from "../../../app/models/activity";
import ActivityList from "./ActivityList";
import ActivityDetails from "../details/ActivityDetails";
import ActivityForm from "../form/ActivityForm";

interface Props {
    activities: Activity[];
    selectActivity: (id: string) => void;
    selectedActivity: Activity | undefined;
    cancleSelectActivity: () => void;
    editMode: boolean;
    openForm: (id: string) => void;
    closeForm: () => void;
    createOrEdit:(activity:Activity)=> void;
    deleteActivity:(id:string) =>void;
}

export default function ActivityDashboard({ deleteActivity,createOrEdit,editMode, openForm, closeForm, activities, selectActivity, selectedActivity, cancleSelectActivity }: Props) {
    return (
        <Grid>
            <Grid.Column width='10'>
                <ActivityList deleteActivity={deleteActivity} activities={activities} selectActivity={selectActivity} />
            </Grid.Column>
            <Grid.Column width='6'>
                {selectedActivity && !editMode && <ActivityDetails openForm={openForm} activity={selectedActivity} cancleSelectActivity={cancleSelectActivity} />}
                {editMode && <ActivityForm createOrEdit={createOrEdit} closeForm={closeForm} activity={selectedActivity} />}
            </Grid.Column>
        </Grid>
    )
}