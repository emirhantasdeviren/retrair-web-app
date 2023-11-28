import "./CartItem.css";

const CartItem = ({ item }) => {
    return (
        <div className="cart-item">
            <img src="https://placehold.co/306x204" />
            <div className="cart-item-info">
                <h3 className="item-title">Long Long Long Item Name</h3>
                <span className="price">Price</span>
                <div>
                    <button>-</button>
                    <span>1</span>
                    <button>+</button>
                </div>
            </div>
        </div>
    );
};

export default CartItem;
