// import { useState } from "react";
import { useFormStatus } from "react-dom";

const wait = (time) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve('Wait is over!');
        }, time);
    });
}

export default function FormAction() {
    // const [pending, setPending] = useState(false);

    const submitAction = async (formData) => {
        // Set pending status
        // setPending(true);

        // Prevent page refresh
        // e.preventDefault();

        // Get form data from DOM
        // const formData = new FormData(e.currentTarget);

        // Get form values
        const username = formData.get('username');
        const password = formData.get('password');

        // Call rest api
        await wait(1500);

        // Remove pending status
        // setPending(false);

        // Cslear form
        // e.target.reset();

        // Result
        console.log(username, password);


    };

    const formActionHandler = (formData) => {

        console.log(formData.get('username'));

        console.log('Form Action Executed!');

    }

    return (
        <div className="flex items-center justify-center min-h-screen bg-gray-100">
            <div className="w-full max-w-sm p-6 bg-white rounded-lg shadow-md">
                <h2 className="text-2xl font-semibold text-center text-gray-700 mb-4">
                    Form Action
                </h2>

                <form action={submitAction} className="space-y-4">
                    <div>
                        <label
                            htmlFor="username"
                            className="block text-sm font-medium text-gray-700"
                        >
                            Username
                        </label>
                        <input
                            type="text"
                            id="username"
                            name="username"
                            className="w-full px-3 py-2 mt-1 border rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 border-gray-300"
                        />
                    </div>

                    <div>
                        <label
                            htmlFor="password"
                            className="block text-sm font-medium text-gray-700"
                        >
                            Password
                        </label>
                        <input
                            type="password"
                            id="password"
                            name="password"
                            className="w-full px-3 py-2 mt-1 border rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 border-gray-300"
                        />
                    </div>

                    <Submit />

                </form>
            </div>
        </div>
    );
}


function Submit() {
    const { pending, data: formData } = useFormStatus;    // {pending, data, method, action }

    return (
        <div>
            <input
                // formAction={submitAction}
                type="submit"
                value="Login"
                disabled={pending}
                className={`w-full px-4 py-2 font-semibold text-white transition bg-blue-600 rounded-md shadow-md ${pending
                    ? "opacity-50 cursor-not-allowed"
                    : "hover:bg-blue-700"
                    }`}
            />
        </div>
    );
}