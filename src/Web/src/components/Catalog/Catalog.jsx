import ProductCard from "../ProductCard/ProductCard";
import "./Catalog.css";

const Catalog = ({ products }) => {
    const listProducts = products.map((p) => (
        <li key={p.id}>
            <ProductCard
                name={p.name}
                price={p.price + "₺"}
                image={p.imagePath}
            />
        </li>
    ));

    return <ul className="catalog">{listProducts}</ul>;
};

export default Catalog;
