import CartItem from "../CartItem/CartItem";
import "./CartList.css";

const CartList = ({ items }) => {
    return (
        <ul className="cart-list">
            <li>
                <CartItem />
            </li>
            <li>
                <CartItem />
            </li>
            <li>
                <CartItem />
            </li>
            <li>
                <CartItem />
            </li>
            <li>
                <CartItem />
            </li>
            <li>
                <CartItem />
            </li>
        </ul>
    );
};

export default CartList;
