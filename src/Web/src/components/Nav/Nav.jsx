import { NavLink } from "react-router-dom";
import "./Nav.css";

const SignInLink = () => (
    <li className="sign-in">
        <NavLink to={"/signin"}>Sign In</NavLink>
    </li>
);

const SignUpLink = () => (
    <li className="sign-up">
        <NavLink to={"/signup"}>Sign Up</NavLink>
    </li>
);

const User = ({ user }) => <li>{user.name}</li>;

const Nav = ({ user }) => {
    return (
        <nav>
            <ul>
                <li>
                    <NavLink to={"/"}>Home</NavLink>
                </li>
                <li>
                    <NavLink to={"/store"}>Store</NavLink>
                </li>
                <li>
                    <a href="/about">About</a>
                </li>
                <li>
                    <a href="/contact">Contact</a>
                </li>
                <li>
                    <NavLink to={"/cart"}>
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            fill="none"
                            viewBox="0 0 24 24"
                            strokeWidth={1.5}
                            stroke="currentColor"
                            className="w-6 h-6"
                        >
                            <path
                                strokeLinecap="round"
                                strokeLinejoin="round"
                                d="M2.25 3h1.386c.51 0 .955.343 1.087.835l.383 1.437M7.5 14.25a3 3 0 00-3 3h15.75m-12.75-3h11.218c1.121-2.3 2.1-4.684 2.924-7.138a60.114 60.114 0 00-16.536-1.84M7.5 14.25L5.106 5.272M6 20.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zm12.75 0a.75.75 0 11-1.5 0 .75.75 0 011.5 0z"
                            />
                        </svg>
                    </NavLink>
                </li>
                {user ? (
                    <User user={user}/>
                ) : (
                    <>
                        <SignInLink />
                        <SignUpLink />
                    </>
                )}
            </ul>
        </nav>
    );
};

export default Nav;
