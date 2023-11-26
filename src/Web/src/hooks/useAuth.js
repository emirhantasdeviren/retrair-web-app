import { useEffect, useState } from "react";

export const useAuth = () => {
    const [user, setUser] = useState(null);

    useEffect(() => {
        const token = sessionStorage.getItem("token");
        if (token) {
            const [header, payload, signature] = token.split(".");
            const user = JSON.parse(atob(payload));

            setUser(user);
        }
    }, []);

    const signIn = (user) => {
        setUser(user);
    };

    const signOut = () => {
        setUser(null);
        sessionStorage.clear();
    };

    return { user, signIn, signOut };
};
