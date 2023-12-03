import { useLoaderData, useOutletContext } from "react-router-dom";
import CheckoutForm from "../components/CheckoutForm/CheckoutForm";

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

const Checkout = () => {
    const cart = useLoaderData();
    const { user } = useOutletContext();

    let items = [];
    if (cart?.items) {
        for (const item of cart.items) {
            for (let i = 0; i < item.quantity; i++) {
                items.push({
                    id: item.id,
                    itemType: 0,
                    name: item.name,
                    price: item.price,
                });
            }
        }
    }
    const totalPrice =
        cart?.items?.reduce((acc, cur) => acc + cur.quantity * cur.price, 0) ??
        0.0;

    return <CheckoutForm user={user} cartId={cart.id} items={items} totalPrice={totalPrice} />;
};

export default Checkout;
