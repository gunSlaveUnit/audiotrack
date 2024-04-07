import { styled } from '@mui/material/styles';
import Button, { ButtonProps } from '@mui/material/Button';

const NavNeuroButton = styled(Button)<ButtonProps>(({ theme }) => ({
    color: theme.palette.getContrastText("#007ba7"),
    '&:hover': {
        backgroundColor: "#156f98",
    },
}));

export default NavNeuroButton;