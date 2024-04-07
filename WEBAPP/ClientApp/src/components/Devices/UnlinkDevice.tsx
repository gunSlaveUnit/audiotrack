import React from "react";
import {Box, Container, FormControlLabel, Paper, Switch} from "@mui/material";
import {DevicesRepository, MedicalInstitutionsRepository, RegionsRepository} from "../../api/repositories/Repository";
import {DataGrid, GridCallbackDetails, GridColDef, GridRowId} from "@mui/x-data-grid";
import {Device} from "../../api/models/Device";
import {Region} from "../../api/models/Region";
import {MedicalInstitution} from "../../api/models/MedicalInstitution";
import DeviceInfo from "./DeviceInfo";

const UnlinkDevice = () => {
    const devicesRepository = new DevicesRepository("devices");
    const regionsRepository = new RegionsRepository("regions");
    const institutionsRepository = new MedicalInstitutionsRepository("medical_institutions");
    
    const [devices, setDevices] = React.useState<Device[]>([]);
    const [regions, setRegions] = React.useState<Region[]>([]);
    const [institutions, setInstitutions] = React.useState<MedicalInstitution[]>([]);

    const [page, setPage] = React.useState<number>(0);
    const [rowsPerPage, setRowsPerPage] = React.useState<number>(15);
    const [dense, setDense] = React.useState<boolean>(false);
    
    const [selectedDeviceId, setSelectedDeviceId] = React.useState<string>('');
    const [isOpen, setIsOpen] = React.useState(false);

    React.useEffect(() => {
        const ds = devicesRepository.GetAsync()
        const rs = regionsRepository.GetAsync()
        const mis = institutionsRepository.GetAsync()

        Promise
            .all([ds, rs, mis])
            .then(([ds, rs, mis]) => {
                setDevices(ds)
                setRegions(rs)
                setInstitutions(mis)
            })
    }, [])
    
    const handleDeviceClicked = (clickedDevice: GridRowId) => {
        setSelectedDeviceId(clickedDevice.toString())

        setIsOpen(true)
    }

    const handleChangeDense = (event: React.ChangeEvent<HTMLInputElement>) => {
        setDense(event.target.checked);
    };

    const handleChangePage = (page: number, details: GridCallbackDetails<any>) => {
        setPage(page);
    };

    const handleChangeRowsPerPage = (newSize: number) => {
        setRowsPerPage(newSize);
        setPage(0);
    };

    const columns: GridColDef[] = [
        {field: "serial_number", headerName: "Серийный номер", flex: 1},
        {field: "region", headerName: "Регион", flex: 1},
        {field: "institution", headerName: "Медицинское учреждение", flex: 1},
    ]

    const rows = devices
        .map(d => ({
            id: d.id,
            region: regions.find(r => r.id == d.region)!.name,
            institution: institutions.find(i => i.id == d.institution)!.name,
            serial_number: d.serial_number,
        }))

    return <Container>
        <Box sx={{width: "100%"}}>
            <Paper sx={{width: "100%", mb: 2}}>
                <div style={{ height: 500, width: '100%' }}>
                    <DataGrid density={dense ? 'compact' : 'comfortable'}
                              rows={rows}
                              columns={columns}
                              pageSize={rowsPerPage}
                              rowsPerPageOptions={[15, 50, 100]}
                              onRowClick={row => handleDeviceClicked(row.id)}
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

        {isOpen &&
            <DeviceInfo id={selectedDeviceId} setIsOpen={setIsOpen}/>
        }
    </Container>
}

export default UnlinkDevice;