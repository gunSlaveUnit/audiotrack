import { styled } from '@mui/material/styles';
import Button, { ButtonProps } from '@mui/material/Button';

const FooterNeuroButton = styled(Button)<ButtonProps>(({ theme }) => ({
    color: "#000",
    '&:hover': {
        backgroundColor: "#ccc",
    },
}));

export default FooterNeuroButton;