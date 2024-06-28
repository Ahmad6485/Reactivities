import React from "react";
import { Button, Item, ItemDescription, ItemExtra, ItemHeader, ItemImage, ItemMeta, Label, List, Segment } from "semantic-ui-react";
import { Activity } from "../../../app/models/activity";

interface Props {
    activities: Activity[];
    selectActivity: (id: string) => void;
    deleteActivity : (id : string) => void;
}

export default function ActivityList({ deleteActivity,selectActivity, activities }: Props) {
    return (
        <Segment>
            <Item.Group divided>
                {activities.map((activity) => (
                    <Item key={activity.id}>
                        <ItemImage size="tiny" src='' />
                        <Item.Content>
                            <ItemHeader as='a'>{activity.title}</ItemHeader>
                            <ItemMeta>{activity.date}</ItemMeta>
                            <ItemDescription>
                                <div>{activity.description}</div>
                                <div>{activity.city},{activity.venue}</div>
                            </ItemDescription>
                            <ItemExtra>
                                <Button floated="right" content='View' color="blue" onClick={() => selectActivity(activity.id)} />
                                <Button floated="right" content='Delete' color="red" onClick={() => deleteActivity(activity.id)} />
                                <Label basic content={activity.category} />
                                {activity.category}</ItemExtra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
}