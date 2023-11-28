import React from "react";
import ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import "./index.css";
import MainLayout from "./layouts/MainLayout";
import Home from "./pages/Home";
import Store, { loader as storeLoader } from "./pages/Store";
import SignIn from "./pages/SignIn";
import SignUp, { action as signUpAction } from "./pages/SignUp";
import ShoppingCart from "./pages/ShoppingCart";

const router = createBrowserRouter([
    {
        path: "/",
        element: <MainLayout />,
        children: [
            {
                index: true,
                element: <Home />,
            },
            {
                path: "/store",
                element: <Store />,
                loader: storeLoader,
            },
            {
                path: "/cart",
                element: <ShoppingCart />,
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
        ],
    },
]);

ReactDOM.createRoot(document.getElementById("root")).render(
    <React.StrictMode>
        <RouterProvider router={router}></RouterProvider>
    </React.StrictMode>
);
