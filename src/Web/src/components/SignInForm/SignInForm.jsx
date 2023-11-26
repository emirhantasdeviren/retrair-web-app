import { useNavigate, useOutletContext } from "react-router-dom";
import "./SignInForm.css";
import { useState } from "react";

const SignInForm = () => {
    const [email, setEmail] = useState(null);
    const [password, setPassword] = useState(null);

    const navigate = useNavigate();
    const { signIn } = useOutletContext();

    return (
        <div className="sign-in-form">
            <div className="sign-in-body">
                <form
                    method="post"
                    className="sign-in"
                    onSubmit={async (event) => {
                        event.preventDefault();

                        const res = await fetch(
                            "http://localhost:8080/api/v1/auth/login",
                            {
                                method: "POST",
                                headers: {
                                    "Content-Type": "application/json",
                                },
                                mode: "cors",
                                body: JSON.stringify({
                                    userName: email,
                                    password: password,
                                }),
                            }
                        );

                        if (res.status === 200) {
                            const { user, token } = await res.json();
                            sessionStorage.setItem("token", token);
                            signIn(user);
                            navigate("/");
                        }
                    }}
                >
                    <label htmlFor="userName">Email</label>
                    <input
                        id="userName"
                        type="email"
                        name="userName"
                        autoComplete="email"
                        onChange={(event) => setEmail(event.target.value)}
                    />
                    <label htmlFor="password">Password</label>
                    <input
                        id="password"
                        type="password"
                        name="password"
                        onChange={(event) => setPassword(event.target.value)}
                    />
                    <button type="submit">Sign in</button>
                </form>
            </div>
        </div>
    );
};

export default SignInForm;
