import React from 'react';
import {BrowserRouter, Routes, Route} from "react-router-dom";
import LinkDevice from "../Devices/LinkDevice";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import Patients from "../Patients/Patients";
import Home from "../Home/Home";
import Container from '@mui/material/Container';
import PatientInfo from "../Patients/PatientInfo";
import SignIn from "../SignIn";
import SignUp from "../SignUp";
import AuthorizeRoute from "../AuthorizeRoute";
import Devices from "../Devices/Devices";
import UnlinkDevice from "../Devices/UnlinkDevice";

const App = () => {
    const [loggedIn, setLoggedIn] = React.useState<boolean>(false);

  return (
    <div className="App">
      <BrowserRouter>
          <Header loggedIn={loggedIn} setLoggedIn={setLoggedIn}/>
          
          <Container maxWidth={"xl"} sx={{marginTop: 1}}>
              <main>
                  <Routes>
                      <Route path="/" element={<Home />} />

                      <Route path='/patients' element={<AuthorizeRoute loggedIn={loggedIn}/>}>
                          <Route path="/patients" element={<Patients />} />
                      </Route>

                      <Route path='/patients/:id' element={<AuthorizeRoute loggedIn={loggedIn}/>}>
                          <Route path="/patients/:id" element={<PatientInfo />} />
                      </Route>

                      <Route path='/devices' element={<AuthorizeRoute loggedIn={loggedIn}/>}>
                          <Route path='/devices' element={<Devices />}/>
                      </Route>
                      <Route path='/devices/link' element={<AuthorizeRoute loggedIn={loggedIn}/>}>
                          <Route path='/devices/link' element={<LinkDevice />}/>
                      </Route>
                      <Route path='/devices/unlink' element={<AuthorizeRoute loggedIn={loggedIn}/>}>
                          <Route path='/devices/unlink' element={<UnlinkDevice />}/>
                      </Route>
                      
                      <Route path="/signin" element={<SignIn setLoggedIn={setLoggedIn}/>} />
                      <Route path="/signup" element={<SignUp setLoggedIn={setLoggedIn}/>} />
                  </Routes>
              </main>

              <Footer />
          </Container>
      </BrowserRouter>
    </div>
  );
}

export default App;
