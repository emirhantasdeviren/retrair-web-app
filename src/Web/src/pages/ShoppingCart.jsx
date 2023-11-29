import { useLoaderData } from "react-router-dom";
import CartList from "../components/CartList/CartList";
import Summary from "../components/Summary/Summary";
import { useState } from "react";

export const loader = async () => {
    const cartId = localStorage.getItem("cartId");

    if (!cartId) {
        return { cartId: null, items: [] };
    }

    const res = await fetch("http://localhost:8080/api/v1/carts/" + cartId);
    if (res.status === 200) {
        return await res.json();
    } else {
        return { cartId: null, items: [] };
    }
};

const ShoppingCart = () => {
    const cart = useLoaderData();
    const [items, setItems] = useState(cart.items);

    return (
        <>
            <CartList items={items} setItems={setItems} />
            <Summary items={items} />
        </>
    );
};

export default ShoppingCart;
