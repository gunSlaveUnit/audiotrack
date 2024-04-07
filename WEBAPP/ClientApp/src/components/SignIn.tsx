import {
    Checkbox,
    FormControl,
    FormControlLabel,
    FormLabel,
    Grid,
    IconButton,
    InputAdornment,
    TextField
} from "@mui/material";
import React from "react";
import {Visibility, VisibilityOff} from "@mui/icons-material";
import ButtonNeuro from "./Common/Buttons/ButtonNeuro";
import {SIGNIN} from "../api/constants/Constants";

interface SignInInfo {
    email: string;
    password: string;
    rememberMe: boolean;
}

const SignIn = ({ setLoggedIn }: {
    readonly setLoggedIn: (loggedIn: boolean) => void;
}) => {
    const [showPassword, setShowPassword] = React.useState<boolean>(false);
    const [values, setValues] = React.useState<SignInInfo>({
        email: '',
        password: '',
        rememberMe: true,
    });

    const handleSignIn = () => {
        fetch(SIGNIN, {
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
        (prop: keyof SignInInfo) => (event: React.ChangeEvent<HTMLInputElement>) => {
            setValues({ ...values, [prop]: event.target.value });
        };

    const handleClickShowPassword = () => {
        setShowPassword(!showPassword)
    }

    const handleMouseDownPassword = (event: React.MouseEvent<HTMLButtonElement>) => {
        event.preventDefault();
    };

    return (
        <Grid container justifyContent={"center"} alignItems={"center"}>
            <FormControl sx={{align: "center", alignItems: "center"}}>
                <FormLabel>Sign In</FormLabel>

                <TextField autoFocus
                           margin={"dense"}
                           sx={{width: "100%"}}
                           id={"email"}
                           label={"Email"}
                           type={"email"}
                           onChange={handleChange('email')}/>

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

                <FormControlLabel control={<Checkbox defaultChecked />} label="Remember Me" />

                <ButtonNeuro onClick={handleSignIn}>Sign In</ButtonNeuro>
            </FormControl>
        </Grid>
    );
}

export default SignIn;