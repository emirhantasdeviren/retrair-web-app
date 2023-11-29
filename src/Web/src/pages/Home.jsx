import { useOutletContext } from "react-router-dom";

const Home = () => {
    const { user } = useOutletContext();
    return <div>{user ? user.name : "Guest"}</div>;
};

export default Home;
