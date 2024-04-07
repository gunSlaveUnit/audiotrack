import {Navigate, Outlet} from "react-router-dom";

const AuthorizeRoute = ({ loggedIn }: { readonly loggedIn: boolean }) => {
     return loggedIn ? <Outlet /> : <Navigate to="/signin" />;
}

export default AuthorizeRoute;