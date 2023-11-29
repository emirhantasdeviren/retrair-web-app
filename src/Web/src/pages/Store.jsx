import { useLoaderData } from "react-router-dom";
import Catalog from "../components/Catalog/Catalog";

export const loader = async () => {
    const res = await fetch("http://localhost:8080/api/v1/products");
    if (res.status === 200) {
        return await res.json();
    } else {
        return null;
    }
};

const Store = () => {
    const products = useLoaderData();

    return <Catalog products={products} />;
};

export default Store;
