import { useState } from "react";
import "./CheckoutForm.css";

const CheckoutForm = ({ user, cartId, items, totalPrice }) => {
    const [name, setName] = useState(null);
    const [surname, setSurname] = useState(null);
    const [identity, setIdentity] = useState(null);
    const [email, setEmail] = useState(null);
    const [address, setAddress] = useState(null);
    const [city, setCity] = useState(null);
    const [country, setCountry] = useState(null);
    const [cardHolderName, setCardHolderName] = useState(null);
    const [cardNumber, setCardNumber] = useState(null);
    const [expMonth, setExpMonth] = useState(null);
    const [expYear, setExpYear] = useState(null);
    const [cvc, setCvc] = useState(null);

    const createPayment = async (event) => {
        event.preventDefault();

        const body = {
            price: totalPrice,
            paidPrice: totalPrice,
            currency: "TRY",
            installment: 1,
            cartId,
            paymentCard: {
                cardHolderName,
                cardNumber,
                expireMonth: expMonth,
                expireYear: expYear,
                cvc,
            },
            buyer: {
                id: user.id,
                name,
                surname,
                identityNumber: identity,
                email,
                registrationAddress: address,
                city,
                country,
            },
            shippingAddress: {
                contactName: name,
                city,
                country,
                details: address,
            },
            billingAddress: {
                contactName: name,
                city,
                country,
                details: address,
            },
            cartItems: items,
        };

        const res = await fetch("http://localhost:8080/api/v1/payment", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(body),
            mode: "cors",
        });

        if (res.status === 200) {
            console.log("Success");
        }
    };

    return (
        <div className="checkout-form-outline">
            <form className="checkout-form" onSubmit={createPayment}>
                <div className="checkout-body">
                    <div className="checkout-input">
                        <label htmlFor="name">Name</label>
                        <input
                            id="name"
                            type="text"
                            name="name"
                            onChange={(event) => setName(event.target.value)}
                        />
                    </div>

                    <div className="checkout-input">
                        <label htmlFor="surname">Surname</label>
                        <input
                            id="surname"
                            type="text"
                            name="surname"
                            onChange={(event) => setSurname(event.target.value)}
                        />
                    </div>

                    <div className="checkout-input checkout-stretch">
                        <label htmlFor="tckn">TCKN</label>
                        <input
                            id="tckn"
                            type="text"
                            name="tckn"
                            onChange={(event) =>
                                setIdentity(event.target.value)
                            }
                        />
                    </div>

                    <div className="checkout-input checkout-stretch">
                        <label htmlFor="email">Email</label>
                        <input
                            id="email"
                            type="email"
                            name="email"
                            autoComplete="email"
                            onChange={(event) => setEmail(event.target.value)}
                        />
                    </div>

                    <div className="checkout-input checkout-stretch">
                        <label htmlFor="address">Address</label>
                        <input
                            id="address"
                            type="text"
                            name="address"
                            onChange={(event) => setAddress(event.target.value)}
                        />
                    </div>

                    <div className="checkout-input">
                        <label htmlFor="city">City</label>
                        <input
                            id="city"
                            type="text"
                            name="city"
                            onChange={(event) => setCity(event.target.value)}
                        />
                    </div>

                    <div className="checkout-input">
                        <label htmlFor="country">Country</label>
                        <input
                            id="country"
                            type="text"
                            name="country"
                            onChange={(event) => setCountry(event.target.value)}
                        />
                    </div>

                    <div className="checkout-input checkout-stretch">
                        <label htmlFor="card-holder-name">
                            Card Holder Name
                        </label>
                        <input
                            id="card-holder-name"
                            type="text"
                            name="card-holder-name"
                            onChange={(event) =>
                                setCardHolderName(event.target.value)
                            }
                        />
                    </div>

                    <div className="checkout-input checkout-stretch">
                        <label htmlFor="card-number">Card Number</label>
                        <input
                            id="card-number"
                            type="text"
                            name="card-number"
                            onChange={(event) =>
                                setCardNumber(event.target.value)
                            }
                        />
                    </div>

                    <div className="checkout-input">
                        <label htmlFor="expire-month">Expiration</label>
                        <div className="expire-date">
                            <input
                                id="expire-month"
                                type="text"
                                name="expire-month"
                                placeholder="MM"
                                onChange={(event) =>
                                    setExpMonth(event.target.value)
                                }
                            />
                            <span>/</span>
                            <input
                                id="expire-year"
                                type="text"
                                name="expire-year"
                                placeholder="YYYY"
                                onChange={(event) =>
                                    setExpYear(event.target.value)
                                }
                            />
                        </div>
                    </div>
                    <div className="checkout-input">
                        <label htmlFor="cvv">CVV</label>
                        <input
                            id="cvv"
                            type="text"
                            name="cvv"
                            onChange={(event) => setCvc(event.target.value)}
                        />
                    </div>
                </div>

                <button className="checkout-btn" type="submit">
                    Checkout
                </button>
            </form>
        </div>
    );
};

export default CheckoutForm;
