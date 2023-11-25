import Nav from "../components/Nav/Nav";
import { Outlet } from "react-router-dom";
import Footer from "../components/Footer/Footer";
import SignIn from "../components/SignIn/SignIn";

const MainLayout = () => {
    return (
        <>
            <Nav />
            <main>
                <Outlet />
                <SignIn />
            </main>
            <Footer />
        </>
    );
};

export default MainLayout;
