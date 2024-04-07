import { styled } from '@mui/material/styles';
import Button, { ButtonProps } from '@mui/material/Button';

const ButtonNeuro = styled(Button)<ButtonProps>(({ theme }) => ({
    color: theme.palette.getContrastText("#0895d0"),
    backgroundColor: "#0895d0",
    '&:hover': {
        backgroundColor: "#156f98",
    },
}));

export default ButtonNeuro;