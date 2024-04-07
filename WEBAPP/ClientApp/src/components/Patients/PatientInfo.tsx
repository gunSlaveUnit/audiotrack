import React, {useEffect} from "react";
import {Patient} from "../../api/models/Patient";
import {Record} from "../../api/models/Record";
import {PatientStatus} from "../../api/models/PatientStatus";
import {Sex} from "../../api/models/Sex";
import {
    HistoryRepository,
    PatientSexesRepository,
    PatientsRepository,
    PatientStatusesRepository
} from "../../api/repositories/Repository";
import {useParams} from "react-router-dom";
import {
    Container, Grid, MenuItem, Select, SelectChangeEvent, Stack,
    Typography, Divider, Card, Table, TableContainer, Paper, TableCell, TableHead, TableRow, TableBody
} from "@mui/material";

const PatientInfo = () => {
    const id = useParams().id;
    
    const patientsRepository = new PatientsRepository("patients");
    const patientStatusesRepository = new PatientStatusesRepository("patient-statuses");
    const patientSexesRepository = new PatientSexesRepository("patient-sexes");
    const historyRepository = new HistoryRepository("history");
    
    const [patient, setPatient] = React.useState<Patient>();
    const [statuses, setStatuses] = React.useState<PatientStatus[]>([]);
    const [sexes, setSexes] = React.useState<Sex[]>([]);
    const [records, setRecords] = React.useState<Record[]>([]);
    
    useEffect(() => {
        const p = patientsRepository.GetItemAsync(id!)
        const s = patientStatusesRepository.GetAsync()
        const sx = patientSexesRepository.GetAsync()

        Promise
            .all([p, s, sx])
            .then(async ([p, s, sx]) => {
                setPatient(p)
                setStatuses(s)
                setSexes(sx)
                setRecords(await historyRepository.GetHistoryForPatient(p!.id))
            })
    }, [])

    const handleStatusChanged = (event: SelectChangeEvent) => {
        let p = patient
        p!.status = event.target.value
        setPatient(p)
        
        patientsRepository
            .UpdateAsync(p!.id, patient!)
                .then(_ => patientsRepository
                    .GetItemAsync(p!.id)
                    .then(
                        async up => {
                            setPatient(up)
                            setRecords(await historyRepository.GetHistoryForPatient(p!.id))
                        }
                    )
                )
    };
    
    return (
        <React.Fragment>
            {patient &&
            <Container>
                <Typography variant={"h3"} sx={{color: "#156f98"}}>Карточка пациента</Typography>

                <Grid container spacing={2} mt={3}>
                    <Grid item xs={6}>
                        <Typography variant={"h4"}>{patient?.lastname}</Typography>
                        <Typography variant={"h4"}>{patient?.name}</Typography>
                        <Typography variant={"h4"}>{patient?.othername}</Typography>
                    </Grid>

                    <Grid item xs={6}>
                        <Stack direction={"row"}>
                            <Typography variant={"h5"}>Дата рождения: </Typography>

                            <Typography ml={1} variant={"h5"}>{new Date(patient!.dateOfBirth).toLocaleString()}</Typography>
                        </Stack>

                        <Stack direction={"row"}>
                            <Typography variant={"h5"}>Пол: </Typography>

                            <Typography ml={1} variant={"h5"}>{sexes.find(s => s.id == patient?.sex)?.sex}</Typography>
                        </Stack>

                        <Stack>
                            <Typography variant={"h5"}>Текущий статус: </Typography>

                            {patient &&
                                <Select value={patient?.status} onChange={handleStatusChanged}>
                                    {statuses.map(s => <MenuItem value={s.id}>{s.status}</MenuItem>)}
                                </Select>
                            }
                        </Stack>
                    </Grid>

                    <Grid item xs={12}>
                        <Divider></Divider>
                    </Grid>

                    <Grid item xs={12}>
                        <Typography variant={"h3"} sx={{color: "#156f98"}}>Обследования</Typography>

                        <Stack>
                            <Card sx={{
                                width: "100%",
                                height: "400px",
                                marginY: "1em",
                                borderRadius: "1.0em",
                                backgroundColor: "#ededed"
                            }}>
                            </Card>

                            <Card sx={{
                                width: "100%",
                                height: "400px",
                                marginY: "1em",
                                borderRadius: "1.0em",
                                backgroundColor: "#ededed"
                            }}>
                            </Card>

                            <Card sx={{
                                width: "100%",
                                height: "400px",
                                marginY: "1em",
                                borderRadius: "1.0em",
                                backgroundColor: "#ededed"
                            }}>
                            </Card>
                        </Stack>
                    </Grid>

                    <Grid item xs={12}>
                        <Divider></Divider>
                    </Grid>


                    <Grid item xs={12}>
                        <Typography variant={"h3"} sx={{color: "#156f98"}}>История</Typography>

                        <TableContainer component={Paper}>
                            <Table>
                                <TableHead>
                                    <TableRow>
                                        <TableCell>Дата изменения</TableCell>
                                        <TableCell>Пользователь</TableCell>
                                        <TableCell>Новый статус</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {records.map(record => (
                                        <TableRow key={record.id}>
                                            <TableCell>{new Date(record.date).toLocaleString()}</TableCell>
                                            <TableCell>{record.user ? record.user : "Система"}</TableCell>
                                            <TableCell>{statuses.find(s => s.id == record.new_status)!.status}</TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </Grid>
                </Grid>
            </Container>
            }
        </React.Fragment>
    );
}

export default PatientInfo;