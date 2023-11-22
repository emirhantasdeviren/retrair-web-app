import ProductCard from "../ProductCard/ProductCard";
import "./Catalog.css";

const Catalog = ({ products }) => {
    return (
        <ul className="catalog">
            <li>
                <ProductCard
                    name="Air Jordan Retro High - Red"
                    price="4990,90₺"
                    image="https://placehold.co/250x150"
                />
            </li>
            <li>
                <ProductCard
                    name="Air Jordan Retro High - Red"
                    price="4990,90₺"
                    image="https://placehold.co/250x150"
                />
            </li>
            <li>
                <ProductCard
                    name="Air Jordan Retro High - Red"
                    price="4990,90₺"
                    image="https://placehold.co/250x150"
                />
            </li>
            <li>
                <ProductCard
                    name="Air Jordan Retro High - Red"
                    price="4990,90₺"
                    image="https://placehold.co/250x150"
                />
            </li>
            <li>
                <ProductCard
                    name="Air Jordan Retro High - Red"
                    price="4990,90₺"
                    image="https://placehold.co/250x150"
                />
            </li>
        </ul>
    );
};

export default Catalog;
