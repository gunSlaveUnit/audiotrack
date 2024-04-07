import Box from "@mui/material/Box";
import Stack from "@mui/material/Stack";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import Divider from "@mui/material/Divider";
import FooterNeuroButton from "../Common/Buttons/FooterNeuroButton";

const Footer = () => {
    return (
        <footer>
            <Stack alignItems="center" bottom={0}>
                <Toolbar>
                    <Box component="img"
                         alt="GURU Store Logo"
                         sx={{
                             height: 50,
                             width: 50,
                         }}
                         src="../favicon.svg"/>

                    Audio Tracking System
                </Toolbar>
                
                <Stack direction={"row"} 
                       justifyContent={"space-between"}
                       spacing={2} 
                       divider={<Divider orientation="vertical" flexItem />}>
                    <FooterNeuroButton>Our website</FooterNeuroButton>
                    <FooterNeuroButton>Contacts</FooterNeuroButton>
                </Stack>

                <Typography mt={2}>
                    &copy; Neurosoft {new Date().getFullYear()}. All rights reserved
                </Typography>
            </Stack>
        </footer>
    );
}

export default Footer;