import "./Summary.css";

const Summary = ({ items }) => {
    const subtotal = items?.reduce((acc, cur) => acc + cur.price, 0) ?? 0.0;
    const shipping = 0.0;

    return (
        <div className="summary">
            <div className="summary-item">
                <div className="summary-label">Subtotal</div>
                <div className="summary-value">
                    {subtotal != 0.0 ? subtotal + "₺" : "31790.90₺"}
                </div>
            </div>
            <div className="summary-item">
                <div className="summary-label">Shipping</div>
                <div className="summary-value">
                    {shipping != 0.0 ? shipping + "₺" : "FREE"}
                </div>
            </div>
            <div className="summary-total">
                <div className="summary-total-label">Total</div>
                <div className="summary-total-value">
                    {subtotal + shipping + "₺"}
                </div>
            </div>
            <button>Check Out</button>
        </div>
    );
};

export default Summary;
