import SignUpForm from "../components/SignUpForm/SignUpForm";

export const action = async ({ request }) => {
    const account = Object.fromEntries(await request.formData());
    const res = await fetch("http://localhost:8080/api/v1/auth/register", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        mode: "cors",
        body: JSON.stringify(account),
    });
    if (res.status === 200) {
        return await res.json();
    } else {
        return null;
    }
};

const SignUp = () => {
    return <SignUpForm />;
};

export default SignUp;
