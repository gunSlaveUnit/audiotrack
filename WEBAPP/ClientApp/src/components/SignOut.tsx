import React from "react";
import ButtonNeuro from "./Common/Buttons/ButtonNeuro";
import {Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Typography} from "@mui/material";
import {SIGNOUT} from "../api/constants/Constants";
import {useNavigate} from "react-router-dom";

const SignOut = ({ setLoggedIn }: {
    readonly setLoggedIn: (loggedIn: boolean) => void;
}) => {
    const [isOpen, setIsOpen] = React.useState(false);
    const navigate = useNavigate();
    
    const handleSignOut = () => {
        fetch(SIGNOUT, {
            method: "POST", 
            credentials: "include"
        })
            .then(_ => {
                setLoggedIn(false)
                navigate("/")
            });
    }

    return (
        <React.Fragment>
            <ButtonNeuro onClick={() => setIsOpen(true)}>Sign Out</ButtonNeuro>

            {isOpen &&
                <Dialog open={isOpen} onClose={setIsOpen}>
                    <DialogTitle>
                        <Typography>Sign Out</Typography>
                    </DialogTitle>
                    <DialogContent>
                        <DialogContentText>
                            <Typography>
                                Are you sure you want to sign out?
                            </Typography>
                        </DialogContentText>
                    </DialogContent>
                    <DialogActions>
                        <ButtonNeuro onClick={handleSignOut}>Sign Out</ButtonNeuro>
                        <Button onClick={() => setIsOpen(false)} variant={"contained"} color="error">
                            <Typography variant={"h6"} textTransform={"capitalize"}>
                                Close
                            </Typography>
                        </Button>
                    </DialogActions>
                </Dialog>
            }
        </React.Fragment>
    );
}

export default SignOut;