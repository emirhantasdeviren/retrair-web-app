import React from "react";
import ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import "./index.css";
import MainLayout from "./layouts/MainLayout";
// import Home from "./pages/Home";
import Store, { loader as storeLoader } from "./pages/Store";
import SignIn from "./pages/SignIn";
import SignUp, { action as signUpAction } from "./pages/SignUp";
import ShoppingCart, {
    loader as shoppingCartLoader,
} from "./pages/ShoppingCart";
import Checkout, { loader as checkoutLoader} from "./pages/Checkout";
import About from "./pages/About";
import Contact from "./pages/Contact";

const router = createBrowserRouter([
    {
        path: "/",
        element: <MainLayout />,
        children: [
            {
                index: true,
                element: <Store />,
                loader: storeLoader,
            },
            {
                path: "/about",
                element: <About />,
            },
            {
                path: "/contact",
                element: <Contact />,
            },
            {
                path: "/cart",
                element: <ShoppingCart />,
                loader: shoppingCartLoader,
            },
            {
                path: "/signin",
                element: <SignIn />,
            },
            {
                path: "/signup",
                element: <SignUp />,
                action: signUpAction,
            },
            {
                path: "/checkout",
                element: <Checkout />,
                loader: checkoutLoader,
            },
        ],
    },
]);

ReactDOM.createRoot(document.getElementById("root")).render(
    <React.StrictMode>
        <RouterProvider router={router}></RouterProvider>
    </React.StrictMode>
);
