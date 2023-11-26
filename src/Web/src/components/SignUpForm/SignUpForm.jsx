import { Form } from "react-router-dom";
import "./SignUpForm.css";

const SignUpForm = () => {
    return (
        <div className="sign-up-form">
            <div className="sign-up-body">
                <Form method="post" className="sign-up">
                    <label htmlFor="name">Name</label>
                    <input id="name" type="text" name="name" />

                    <label htmlFor="email">Email</label>
                    <input
                        id="email"
                        type="email"
                        name="email"
                        autoComplete="email"
                    />

                    <label htmlFor="phone">Phone Number</label>
                    <input id="phone" type="tel" name="phoneNumber" />

                    <label htmlFor="password">Password</label>
                    <input id="password" type="password" name="password" />

                    <button type="submit">Sign up</button>
                </Form>
            </div>
        </div>
    );
};

export default SignUpForm;
