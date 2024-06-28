import { Button, Container, Menu } from "semantic-ui-react";

interface Props{
    formOpen:() =>void;
}

export default function NavBar({formOpen}:Props)
{
    return(
        <Menu inverted fixed="top">
            <Container>
                <Menu.Item header>
                    <img style={{marginRight:'10px'}} src="/assets/logo.png" alt="logo" />
                    Reactivities
                </Menu.Item>
                <Menu.Item name="Activities" />
                <Menu.Item>
                    <Button positive content='Create Activity' onClick={formOpen} />
                </Menu.Item>
            </Container>
        </Menu>
    )
}