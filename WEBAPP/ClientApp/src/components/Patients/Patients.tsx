import {PatientSexesRepository, PatientsRepository, PatientStatusesRepository} from "../../api/repositories/Repository";
import React from "react";
import { useNavigate } from "react-router-dom";
import {Patient} from "../../api/models/Patient";
import {PatientStatus} from "../../api/models/PatientStatus";
import {DataGrid, GridCallbackDetails, GridColDef, GridRowId} from "@mui/x-data-grid";
import {Sex} from "../../api/models/Sex";
import {Box, Container, FormControlLabel, Paper, Switch, TablePagination} from "@mui/material";

const Patients = () => {
    const navigate = useNavigate()
    
    const patientsRepository = new PatientsRepository("patients");
    const patientStatusesRepository = new PatientStatusesRepository("patient-statuses");
    const patientSexesRepository = new PatientSexesRepository("patient-sexes");
    const [patients, setPatients] = React.useState<Patient[]>([]);
    const [statuses, setStatuses] = React.useState<PatientStatus[]>([]);
    const [sexes, setSexes] = React.useState<Sex[]>([]);

    const [page, setPage] = React.useState<number>(0);
    const [rowsPerPage, setRowsPerPage] = React.useState<number>(15);
    const [dense, setDense] = React.useState<boolean>(false);

    React.useEffect(() => {
        const p = patientsRepository.GetAsync()
        const s = patientStatusesRepository.GetAsync()
        const sx = patientSexesRepository.GetAsync()

        Promise
            .all([p, s, sx])
            .then(([p, s, sx]) => {
                setPatients(p)
                setStatuses(s)
                setSexes(sx)
            })
    }, [])

    const columns: GridColDef[] = [
        {field: "name", headerName: "Имя", flex: 1},
        {field: "lastname", headerName: "Фамилия", flex: 1},
        {field: "othername", headerName: "Отчество", flex: 1},
        {field: "dateOfBirth", headerName: "Дата рождения", type: "dateTime", flex: 1},
        {field: "sex", headerName: "Пол", flex: 1},
        {field: "status", headerName: "Текущий статус", flex: 1}
    ]

    const rows = patients
        .map(p => ({
            id: p.id,
            name: p.name,
            lastname: p.lastname,
            othername: p.othername,
            dateOfBirth: new Date(p.dateOfBirth).toLocaleString(),
            sex: sexes.find(sx => sx.id == p.sex)!.sex,
            status: statuses.find(s => s.id == p.status)!.status
        }))

    const handlePatientRowClick = (clickedPatientId: GridRowId) => {
        navigate(`/patients/${clickedPatientId}`)
    }
    
    const  handleChangeDense = (event: React.ChangeEvent<HTMLInputElement>) => {
        setDense(event.target.checked);
    };

    const handleChangePage = (page: number, details: GridCallbackDetails<any>) => {
        setPage(page);
    };

    const handleChangeRowsPerPage = (newSize: number) => {
        setRowsPerPage(newSize);
        setPage(0);
    };
    
    return (
        <Container>
            <Box sx={{width: "100%"}}>
                <Paper sx={{width: "100%", mb: 2}}>
                    <div style={{ height: 500, width: '100%' }}>
                        <DataGrid density={dense ? 'compact' : 'comfortable'}
                                  rows={rows}
                                  columns={columns}
                                  pageSize={rowsPerPage}
                                  rowsPerPageOptions={[15, 50, 100]}
                                  onRowClick={row => handlePatientRowClick(row.id)}
                                  page={page}
                                  onPageSizeChange={(newSize) => handleChangeRowsPerPage(newSize)}
                                  onPageChange={(page, details) => handleChangePage(page, details)}
                        />
                    </div>
                </Paper>

                <FormControlLabel
                    control={<Switch checked={dense} onChange={handleChangeDense} />}
                    label="Компактнее"
                />
            </Box>
        </Container>
    );
}

export default Patients;