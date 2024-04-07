import {DevicesRepository, MedicalInstitutionsRepository, RegionsRepository} from "../../api/repositories/Repository";
import {Code} from "../../api/models/Code";
import React, {useEffect} from "react";
import ButtonNeuro from "../Common/Buttons/ButtonNeuro";
import Alert from "@mui/material/Alert";
import {
    Container,
    Grid,
    Stack,
    Box,
    Typography,
    MenuItem,
    Select,
    SelectChangeEvent,
    InputLabel,
    FormControl
} from "@mui/material";
import {Region} from "../../api/models/Region";
import {MedicalInstitution} from "../../api/models/MedicalInstitution";

const LinkDevice = () => {
    const devicesRepository = new DevicesRepository("devices");
    const regionsRepository = new RegionsRepository("regions");
    const medicalInstitutionsRepository = new MedicalInstitutionsRepository("medical_institutions");
    
    const [code, setCode] = React.useState<Code>();
    const [regions, setRegions] = React.useState<Region[]>([]);
    const [institutions, setInstitutions] = React.useState<MedicalInstitution[]>([]);
    const [selectedRegion, setSelectedRegion] = React.useState('');
    const [selectedInstitution, setSelectedInstitution] = React.useState('');
    
    useEffect(() => {
        const rs = regionsRepository.GetAsync()

        Promise
            .all([rs])
            .then(([rs]) => {
                setRegions(rs)
            })
    }, [])
    
    const getCode = () => {
        devicesRepository.GetCode({
            region: selectedRegion,
            institution: selectedInstitution
        })
            .then(c => setCode(c))
    }
    
    const handleRegionChanged = (event: SelectChangeEvent) => {
        let newRegion = event.target.value as string;
        setSelectedRegion(newRegion);
        
        setSelectedInstitution('');

        const mis = medicalInstitutionsRepository.GetAsyncByRegion(newRegion)

        Promise
            .all([mis])
            .then(([mis]) => {
                setInstitutions(mis)
            })
    }

    const handleInstitutionChanged = (event: SelectChangeEvent) => {
        setSelectedInstitution(event.target.value as string);
    }
    
    return (
        <Container className={"LinkDevice"}>
            <Typography variant={"h3"} sx={{color: "#156f98"}}>Пошаговая инструкция, привязка устройства: </Typography>
            
            <Box className={"Instruction"} mt={2}>
                <Box className={"RegionSelection"}>
                    <Typography variant={"h5"}>1. Выберите регион, в котором находится данное устройство</Typography>

                    <FormControl fullWidth sx={{marginTop: 1}}>
                        <InputLabel id="demo-simple-select-label">Регион</InputLabel>
                        
                        <Select labelId="demo-simple-select-label"
                                id="demo-simple-select"
                                value={selectedRegion}
                                label="Регион" onChange={handleRegionChanged}>
                            {regions.map(r => <MenuItem value={r.id}>{r.name}</MenuItem>)}
                        </Select>
                    </FormControl>
                </Box>

                <Box className={"MedicalInstitutionSelection"} mt={2}>
                    <Typography variant={"h5"}>2. После этого появится список медицинских учреждений, зарегистрированных в этом регионе. Выберите одно из них</Typography>

                    {selectedRegion &&
                        <FormControl fullWidth sx={{marginTop: 1}}>
                            <InputLabel id="demo-simple-select-label">Медицинское учреждение</InputLabel>

                            <Select labelId="demo-simple-select-label"
                                    id="demo-simple-select"
                                    value={selectedInstitution}
                                    label="Медицинское учреждение" onChange={handleInstitutionChanged}>
                                {institutions.map(i => <MenuItem value={i.id}>{i.name}</MenuItem>)}
                            </Select>
                        </FormControl>
                    }
                </Box>

                <Box className={"CodeGeneration"} mt={2}>
                    <Typography variant={"h5"}>3. Нажмите на кнопку "Получить код"</Typography>

                    <Grid container mt={1} style={{alignItems: "center", justifyContent: "center"}}>
                        <ButtonNeuro variant="contained" onClick={getCode} size={"large"}>Получить код</ButtonNeuro>
                    </Grid>
                </Box>

                <Box display="flex"
                     justifyContent="center"
                     alignItems="center" mt={2} className={"Code"}>
                    <Stack direction={"row"} alignItems="center">
                        <Typography variant={"h5"}>
                            Код подтверждения:
                        </Typography>

                        {code ?
                            <Typography ml={1} variant={"h5"} style={{color: "#007ba7"}}>{code.code}</Typography>
                            :
                            <Typography ml={1} variant={"h5"} style={{color: "#bebebe"}}>* ваш код будет здесь *</Typography>
                        }
                    </Stack>
                </Box>
            </Box>
        </Container>
    );
}

export default LinkDevice;
