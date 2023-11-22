import "./ProductCard.css";

const ProductCard = ({ name, price, image }) => {
    return (
        <div className="product-card">
            <img src={image} />
            <h3>{name}</h3>
            <span>{price}</span>
            <button>Add to cart</button>
        </div>
    );
};

export default ProductCard;
