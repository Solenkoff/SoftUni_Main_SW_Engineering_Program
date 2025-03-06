import { useState, useTransition } from "react";

const wait = (time) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve('Wait is over!');
        }, time);
    });
}

export default function UseTransition() {
    const [name, setName] = useState('');
    const [isPending, startTransition] = useTransition();

    const submitHandler = (e) => {
        // Prevent page refresh
        e.preventDefault();
  
        // Get form data from DOM
        const formData = new FormData(e.currentTarget);

        // Get form values
        const character = formData.get('character');
        
        startTransition( async () => {
            // Call rest api
            const response = await fetch(`https://swapi.dev/api/people/${character}`);
            const result = await response.json();
            
            startTransition(() => setName(result.name));
        });
    };

    return (
        <div className="flex items-center justify-center min-h-screen bg-gray-100">
            <div className="w-full max-w-sm p-6 bg-white rounded-lg shadow-md">
                <h2 className="text-2xl font-semibold text-center text-gray-700 mb-4">
                    Use Transition
                </h2>
   
                <form onSubmit={submitHandler} className="space-y-4">
                    <div>
                        <label
                            htmlFor="character"
                            className="block text-sm font-medium text-gray-700"
                        >
                            Character - {name}
                        </label>
                        <input
                            type="text"
                            id="character"
                            name="character"
                            className="w-full px-3 py-2 mt-1 border rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 border-gray-300"
                        />
                    </div>

                    <div>
                        <input
                            type="submit"s
                            value="Get"
                            // disabled={pending}
                            className={`w-full px-4 py-2 font-semibold text-white transition bg-blue-600 rounded-md shadow-md ${isPending
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