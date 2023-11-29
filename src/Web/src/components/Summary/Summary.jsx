import "./Summary.css";

const Summary = ({ items }) => {
    const subtotal = items?.reduce((acc, cur) => acc + cur.quantity * cur.price, 0) ?? 0.0;
    const shipping = 0.0;

    return (
        <div className="summary">
            <div className="summary-item">
                <div className="summary-label">Subtotal</div>
                <div className="summary-value">
                    {subtotal != 0.0 ? subtotal.toFixed(2) + "₺" : "0₺"}
                </div>
            </div>
            <div className="summary-item">
                <div className="summary-label">Shipping</div>
                <div className="summary-value">
                    {shipping != 0.0 ? shipping.toFixed(2) + "₺" : "FREE"}
                </div>
            </div>
            <div className="summary-total">
                <div className="summary-total-label">Total</div>
                <div className="summary-total-value">
                    {(subtotal + shipping).toFixed(2) + "₺"}
                </div>
            </div>
            <button>Check Out</button>
        </div>
    );
};

export default Summary;
