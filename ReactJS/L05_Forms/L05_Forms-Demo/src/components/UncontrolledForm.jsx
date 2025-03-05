import { useState } from "react";

const wait = (time) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve('Wait is over!');
        }, time);
    });
}

export default function UncontrolledForm() {
    const [pending, setPending] = useState(false);

    const submitHandler = async (e) => {
        // Set pending status
        setPending(true);

        // Prevent page refresh
        e.preventDefault();

        // Get form data
        const formData = new FormData(e.currentTarget);

        // Get form values
        const username = formData.get('username');
        const password = formData.get('password');

        // Call rest api
        await wait(1500);

        // Remove pending status
        setPending(false);

        // Result
        console.log(username, password);


    };

    return (
        <div className="flex items-center justify-center min-h-screen bg-gray-100">
            <div className="w-full max-w-sm p-6 bg-white rounded-lg shadow-md">
                <h2 className="text-2xl font-semibold text-center text-gray-700 mb-4">
                    Uncontrolled Form
                </h2>

                <form onSubmit={submitHandler} className="space-y-4">
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
                            defaultValue="Pesho"
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

                    <div>
                        <input
                            type="submit"
                            value="Login"
                            disabled={pending}
                            className={`w-full px-4 py-2 font-semibold text-white transition bg-blue-600 rounded-md shadow-md ${pending
                                ? "opacity-50 cursor-not-allowed"
                                : "hover:bg-blue-700"
                                }`}
                        />
                    </div>
                </form>
            </div>
        </div>
    );
}