import {
    FormControl,
    FormLabel,
    IconButton,
    InputAdornment,
    Grid,
    TextField,
} from "@mui/material";
import ButtonNeuro from "./Common/Buttons/ButtonNeuro";
import {Visibility, VisibilityOff} from "@mui/icons-material";
import React from "react";
import {SIGNUP} from "../api/constants/Constants";

interface SignUpInfo {
    email: string;
    name: string;
    password: string;
    passwordConfirm: string;
}

const SignUp = ({ setLoggedIn }: {
    readonly setLoggedIn: (loggedIn: boolean) => void;
}) => {
    const [showPassword, setShowPassword] = React.useState<boolean>(false);
    const [values, setValues] = React.useState<SignUpInfo>({
        email: '',
        name: '',
        password: '',
        passwordConfirm: ''
    });
    
    const handleSignUp = () => {
        fetch(SIGNUP, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(values),
            credentials: "include"
        })
            .then(r => {
                if (r.ok)
                    setLoggedIn(true)
            })
    }

    const handleChange =
        (prop: keyof SignUpInfo) => (event: React.ChangeEvent<HTMLInputElement>) => {
            setValues({ ...values, [prop]: event.target.value });
        };

    const handleClickShowPassword = () => {
        setShowPassword(!showPassword)
    }

    const handleMouseDownPassword = (event: React.MouseEvent<HTMLButtonElement>) => {
        event.preventDefault();
    };
    
    return (
        <Grid container justifyContent={"center"} alignItems={"center"} sx={{width: "100%"}}>
            <FormControl sx={{align: "center", alignItems: "center"}}>
                <FormLabel>Sign Up</FormLabel>
                
                <TextField autoFocus 
                           margin={"dense"}
                           sx={{width: "100%"}}
                           id={"email"} 
                           label={"Email"} 
                           type={"email"} 
                           onChange={handleChange('email')}/>
                
                <TextField sx={{width: "100%"}}
                           margin={"dense"}
                           id={"name"} 
                           label={"First Name"} 
                           type={"text"} 
                           onChange={handleChange('name')}/>
                
                <TextField id="password"
                           sx={{width: "100%"}}
                           margin={"dense"}
                           type={showPassword ? 'text' : 'password'}
                           value={values.password}
                           onChange={handleChange('password')}
                           label="Password"
                           InputProps={{
                               endAdornment: (
                                   <InputAdornment position={"end"}>
                                       <IconButton
                                           aria-label="toggle password visibility"
                                           onClick={handleClickShowPassword}
                                           onMouseDown={handleMouseDownPassword}
                                           edge="end">
                                           {showPassword ? <VisibilityOff /> : <Visibility />}
                                       </IconButton>
                                   </InputAdornment>
                               ), 
                           }}
                />
                
                <TextField sx={{width: "100%"}}
                           id={"passwordConfirm"}
                           margin={"dense"}
                           label={"Confirm password"} 
                           type={"password"} 
                           onChange={handleChange('passwordConfirm')}/>
                
                <ButtonNeuro onClick={handleSignUp}>Sign Up</ButtonNeuro>
            </FormControl>
        </Grid>
    );
}

export default SignUp;