import React, {useEffect} from "react";
import ButtonNeuro from "../Common/Buttons/ButtonNeuro";
import {Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Typography} from "@mui/material";
import {DevicesRepository, MedicalInstitutionsRepository, RegionsRepository} from "../../api/repositories/Repository";
import {Device} from "../../api/models/Device";

const DeviceInfo = ({ 
    id, 
    setIsOpen 
} : { 
    readonly id: string, 
    readonly setIsOpen: (isOpen: boolean) => void 
}) => {
    const devicesRepository = new DevicesRepository("devices");
    const regionsRepository = new RegionsRepository("regions");
    const institutionsRepository = new MedicalInstitutionsRepository("medical_institutions");
    
    const [device, setDevice] = React.useState<Device>();
    
    useEffect(() => {
        (async () => {
            const d = await devicesRepository.GetItemAsync(id!)
            const r = await regionsRepository.GetItemAsync(d!.region)
            const i = await institutionsRepository.GetItemAsync(d!.institution)

            console.log(d)

            const deviceWithMappedData = d;
            deviceWithMappedData.region = r.name
            deviceWithMappedData.institution = i.name

            setDevice(deviceWithMappedData)
        })();
    }, [])
    
    const handleUnlinkDevice = () => {
        devicesRepository.DeleteAsync(id!)
            .then(_ => setIsOpen(false))
    }
    
    return (
        <React.Fragment>
            {device &&
                <Dialog onClose={setIsOpen} open={true}>
                    <DialogTitle>
                        <Typography>Устройство: {device!.serial_number}</Typography>
                    </DialogTitle>
                    <DialogContent>
                        <DialogContentText>
                            <Typography>
                                Зарегистрировано в: {device!.region}
                            </Typography>
                            Мед. учреждение: {device!.institution}
                            <Typography>

                            </Typography>
                        </DialogContentText>
                    </DialogContent>
                    <DialogActions>
                        <Typography>
                            Доступные действия:
                        </Typography>

                        <ButtonNeuro onClick={handleUnlinkDevice} sx={{marginLeft: 1}} size={"large"}>Отвязать</ButtonNeuro>

                        <Button onClick={() => setIsOpen(false)} variant={"contained"} color="error">
                            <Typography variant={"h6"} textTransform={"capitalize"}>
                                Закрыть
                            </Typography>
                        </Button>
                    </DialogActions>
                </Dialog>
            }
        </React.Fragment>
    );
}

export default DeviceInfo;