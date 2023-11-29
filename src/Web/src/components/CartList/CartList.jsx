import CartItem from "../CartItem/CartItem";
import "./CartList.css";

const CartList = ({ items, setItems }) => {
    const itemsList = items.map((i) => {
        const updateQuantity = (quantity) => {
            setItems((prevItems) => {
                const newItems = prevItems.map((prevItem) =>
                    prevItem.id === i.id ? { ...prevItem, quantity } : prevItem,
                );

                return newItems;
            });
        };

        const removeItem = () => {
            setItems((prevItems) => {
                const newItems = prevItems.filter(
                    (prevItem) => prevItem.id !== i.id,
                );

                return newItems;
            });
        };

        return (
            <li key={i.id}>
                <CartItem
                    item={i}
                    updateQuantity={updateQuantity}
                    removeItem={removeItem}
                />
            </li>
        );
    });

    return <ul className="cart-list">{itemsList}</ul>;
};

export default CartList;
