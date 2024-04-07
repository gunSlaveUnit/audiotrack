import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import {Link} from "react-router-dom";
import ButtonNeuro from "../Common/Buttons/ButtonNeuro";
import NavNeuroButton from "../Common/Buttons/NavNeuroButton";
import React, {useEffect} from "react";
import SignOut from "../SignOut";

const Header = (
    { 
        loggedIn, 
        setLoggedIn 
    } : { 
        readonly loggedIn: boolean;
        readonly setLoggedIn: (loggedIn: boolean) => void;
    }) => {
    
    return (
        <header>
            <AppBar position={"static"} style={{backgroundColor: "#007ba7"}}>
                <Toolbar sx={{justifyContent: "space-between"}}>
                    <Toolbar sx={{width: "content"}}>
                        <Box component="img"
                             alt="GURU Store Logo"
                             sx={{
                                 height: 50,
                                 width: 50,
                             }}
                             src="../favicon.svg"/>

                        Audio Tracking System
                    </Toolbar>
                    
                    <Toolbar sx={{justifyContent: "space-around"}}>
                        <nav>
                            <Link to={"/patients"} style={{textDecoration: 'none'}}>
                                <NavNeuroButton>Patients</NavNeuroButton>
                            </Link>
                            
                            <Link to={"/devices"} style={{textDecoration: 'none'}}>
                                <NavNeuroButton>Devices</NavNeuroButton>
                            </Link>
                        </nav>
                    </Toolbar>

                    {!loggedIn ?
                        <Toolbar>
                            <Link to={"/signin"} style={{textDecoration: 'none'}}>
                                <ButtonNeuro sx={{mr: 1}}>Sign In</ButtonNeuro>
                            </Link>

                            <Link to={"/signup"} style={{textDecoration: 'none'}}>
                                <ButtonNeuro>Sign Up</ButtonNeuro>
                            </Link>
                        </Toolbar>
                            :
                        <SignOut setLoggedIn={setLoggedIn}/>
                    }
                </Toolbar>
            </AppBar>
        </header>
    );
}

export default Header;