import { useOutletContext } from "react-router-dom";
import "./ProductCard.css";

const ProductCard = ({ id, name, price, image, toaster, status }) => {
    const { user } = useOutletContext();

    const onClick = async (event) => {
        event.preventDefault();
        const cartId = localStorage.getItem("cartId");

        toaster(true);
        status(null);

        if (cartId) {
            const body = { productId: id };

            const res = await fetch(
                "http://localhost:8080/api/v1/carts/" + cartId + "/items",
                {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    mode: "cors",
                    body: JSON.stringify(body),
                },
            );

            if (res.status === 204) {
                console.log("Product added to shopping cart");
                status(true);
            } else status(false);
        } else {
            const body = {
                customerId: user?.sub,
                productId: id,
            };

            const res = await fetch("http://localhost:8080/api/v1/carts", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                mode: "cors",
                body: JSON.stringify(body),
            });

            if (res.status === 200) {
                const cart = await res.json();
                localStorage.setItem("cartId", cart.id);
                console.log("Product added to shopping cart");
                status(true);
            } else status(false);
        }
    };

    return (
        <>
            <div className="product-card">
                <img src={image} />
                <h3>{name}</h3>
                <span>{price}</span>
                <button onClick={onClick}>Add to cart</button>
            </div>
        </>
    );
};

export default ProductCard;
