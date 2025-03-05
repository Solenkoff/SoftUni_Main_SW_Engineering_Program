import { useRef } from "react";
import './UncontrolledFormRef.css';


const wait = (time) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve('Wait is over!');
        }, time);
    });
}

//* Do NOT  do this -> just as learnig example about Ref
export default function UncontrolledFormRef() {
    // - const [pending, setPending] = useState(false);
    const submitRef = useRef();

    const submitHandler = async (e) => {
        // Set pending status
        // - setPending(true);
        submitRef.current.disabled = true;

        // Prevent page refresh
        e.preventDefault();

        // Get form data from DOM
        const formData = new FormData(e.currentTarget);

        // Get form values
        const username = formData.get('username');
        const password = formData.get('password');

        // Call rest api
        await wait(1500);

        // Remove pending status
        // - setPending(false);
        submitRef.current.disabled = false;

        // Result
        console.log({ username: username, password: password });


    };

    return (
        <div className="flex items-center justify-center min-h-screen bg-gray-100">
            <div className="w-full max-w-sm p-6 bg-white rounded-lg shadow-md">
                <h2 className="text-2xl font-semibold text-center text-gray-700 mb-4">
                    Uncontrolled Form Ref
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

                    <Submit ref={submitRef} />
                </form>
            </div>
        </div>
    );
}


function Submit({ ref }) {
    return (
        <div>
            <input
                ref={ref}
                type="submit"
                value="Login"
                className={"submit-btn w-full px-4 py-2 font-semibold text-white transition bg-blue-600 rounded-md shadow-md"}
            />
        </div>
    );
} 