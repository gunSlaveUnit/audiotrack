import {Container, Card, CardMedia, CardContent, CardActionArea, Grid, Typography, Stack} from "@mui/material";
import AddLinkIcon from '@mui/icons-material/AddLink';
import LinkOffIcon from '@mui/icons-material/LinkOff';
import React from "react";
import {useNavigate} from "react-router-dom";

const Devices = () => {
    const navigate = useNavigate();
    
    return <Container>
        <Grid container alignItems="center"
              justifyContent="center">
            <Grid item xs={6} sx={{display: "flex",
                justifyContent: "center",
                alignItems: "center"}}>
                <Card sx={{borderRadius: "1.8em", maxWidth: "90%"}}>
                    <CardActionArea onClick={() => navigate("/devices/link")}>
                        <CardMedia>
                            <Stack alignItems="center">
                                <AddLinkIcon sx={{fontSize: "150px", color: "#30BA8F"}}/>
                            </Stack>
                        </CardMedia>
                        <CardContent>
                            <Typography gutterBottom variant="h5" component="div">
                                Привязать устройство
                            </Typography>
                            <Typography variant="body1" color="text.secondary">
                                Привяжите ваше устройство, введя нужную сервису информацию, 
                                сгенерировав код подтверждения и получив уникальный ключ доступа
                            </Typography>
                        </CardContent>
                    </CardActionArea>
                </Card>
            </Grid>

            <Grid item xs={6} sx={{display: "flex",
                justifyContent: "center",
                alignItems: "center"}}>
                <Card sx={{borderRadius: "1.8em", maxWidth: "90%",
                    display: "flex",
                    justifyContent: "center",
                    alignItems: "center"}}>
                    <CardActionArea onClick={() => navigate("/devices/unlink")}>
                        <CardMedia>
                            <Stack alignItems="center">
                                <LinkOffIcon sx={{fontSize: "150px", color: "#7a9cbc"}}/>
                            </Stack>
                        </CardMedia>
                        <CardContent>
                            <Typography gutterBottom variant="h5" component="div">
                                Отвязать устройство
                            </Typography>
                            <Typography variant="body1" color="text.secondary">
                                Отвяжите ваше устройство для новой привязки или для его замены путем его выбора из списка и подтверждения операции
                            </Typography>
                        </CardContent>
                    </CardActionArea>
                </Card>
            </Grid>
        </Grid>
    </Container>
}

export default Devices;