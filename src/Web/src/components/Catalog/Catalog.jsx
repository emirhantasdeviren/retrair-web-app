import { useState, useContext, useEffect } from "react";
import ProductCard from "../ProductCard/ProductCard";
import "./Catalog.css";

const Catalog = ({ products }) => {
    const [toaster, setToaster] = useState(false);
    const [status, setStatus] = useState(null);

    const listProducts = products.map((p) => (
        <li key={p.id}>
            <ProductCard
                id={p.id}
                name={p.name}
                price={p.price + "₺"}
                image={p.imagePath}
                toaster={setToaster}
                status={setStatus}
            />
        </li>
    ));

    if (toaster)
        setTimeout(() => {
            setToaster(false);
        }, 1500);

    return (
        <>
            {toaster && (
                <div className="toaster">
                    {status === null ? (
                        <p>loading...</p>
                    ) : status ? (
                        <p>Product added.</p>
                    ) : (
                        <p>Product could not be added.</p>
                    )}
                </div>
            )}
            <ul className="catalog">{listProducts}</ul>
        </>
    );
};

export default Catalog;
