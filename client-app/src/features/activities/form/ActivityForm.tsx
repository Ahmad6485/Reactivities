import React, { ChangeEvent, useState } from "react";
import { Button, Form, Segment } from "semantic-ui-react";
import { Activity } from "../../../app/models/activity";

interface Props {
    closeForm: () => void;
    activity: Activity | undefined;
    createOrEdit:(activity:Activity)=> void;
}

export default function ActivityForm({createOrEdit, closeForm, activity: selectedACtivity }: Props) {
    const InitialState = selectedACtivity ??
    {
        id: '',
        title: '',
        date: '',
        description: '',
        category: '',
        city: '',
        venue: '',
    }
    const [activity, setActivity] = useState(InitialState);

    function handleSubmit() {
        //console.log(activity);
        createOrEdit(activity);
    }
    const handleInputChange = (event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = event.target;
        setActivity({ ...activity, [name]: value });
    };

    
    return (
        <Segment clearing>
            <Form autoComplete='off' onSubmit={handleSubmit}>
                <Form.Input placeholder='Title' defaultValue={activity.title} name='title' onChange={handleInputChange} />
                <Form.TextArea placeholder='Description' defaultValue={activity.description} name='description' onChange={handleInputChange} />
                <Form.Input placeholder='Category' defaultValue={activity.category} name='category' onChange={handleInputChange} />
                <Form.Input placeholder='Date' defaultValue={activity.date} name='date' onChange={handleInputChange} />
                <Form.Input placeholder='City' defaultValue={activity.city} name='city' onChange={handleInputChange} />
                <Form.Input placeholder='Venue' defaultValue={activity.venue} name='venue' onChange={handleInputChange} />
                <Button content='Submit' positive type="submit" floated="right" />
                <Button content='Cancel' type="button" floated="right" onClick={closeForm} />
            </Form>
        </Segment>
    )
}