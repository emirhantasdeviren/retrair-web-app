import "./CartItem.css";

const _updateQuantity = async (itemId, quantity) => {
    const cartId = localStorage.getItem("cartId");

    if (cartId) {
        const body = { quantity };
        const res = await fetch(
            "http://localhost:8080/api/v1/carts/" + cartId + "/items/" + itemId,
            {
                method: "PATCH",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(body),
                mode: "cors",
            },
        );

        return res;
    }

    return Response({ error: "Cart does not exists" }, { status: 400 });
};

const _removeItem = async (itemId) => {
    const cartId = localStorage.getItem("cartId");

    if (cartId) {
        const res = await fetch(
            "http://localhost:8080/api/v1/carts/" + cartId + "/items/" + itemId,
            {
                method: "DELETE",
                mode: "cors",
            },
        );

        return res;
    }

    return Response({ error: "Cart does not exists" }, { status: 400 });
};

const CartItem = ({ item, updateQuantity, removeItem }) => {
    const increment = async (event) => {
        event.preventDefault();

        const res = await _updateQuantity(item.id, item.quantity + 1);
        if (res.status === 204) {
            updateQuantity(item.quantity + 1);
        }
    };

    const decrement = async (event) => {
        event.preventDefault();

        if (item.quantity > 1) {
            const res = await _updateQuantity(item.id, item.quantity - 1);
            if (res.status === 204) {
                updateQuantity(item.quantity - 1);
            }
        } else {
            const res = await _removeItem(item.id);
            if (res.status === 204) {
                removeItem();
            }
        }
    };

    return (
        <div className="cart-item">
            <img src={item.imagePath} />
            <div className="cart-item-info">
                <h3 className="item-title">{item.name}</h3>
                <span className="price">{item.price + "₺"}</span>
                <div>
                    <button onClick={decrement}>-</button>
                    <span>{item.quantity}</span>
                    <button onClick={increment}>+</button>
                </div>
            </div>
        </div>
    );
};

export default CartItem;
