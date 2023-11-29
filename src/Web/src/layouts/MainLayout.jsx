import Nav from "../components/Nav/Nav";
import { Outlet } from "react-router-dom";
import Footer from "../components/Footer/Footer";
import { useAuth } from "../hooks/useAuth";

const MainLayout = () => {
    const auth = useAuth();

    return (
        <>
            <Nav user={auth.user} />
            <main>
                <Outlet context={auth} />
            </main>
            <Footer />
        </>
    );
};

export default MainLayout;
