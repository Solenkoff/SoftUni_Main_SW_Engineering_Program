// import { useState } from "react";
import { useActionState } from "react";
import { useFormStatus } from "react-dom";


export default function UseActionState() {
    const action = async (state, formData) => {
        const charId = formData.get('character');
        // Call rest api
        const response = await fetch(`https://swapi.dev/api/people/${charId}`);
        const result = await response.json();

        // Result
        return result.name;
    };

    const initialFormState = { character: '' };

    // This formAction is Client action (works in transition)
    const [state, formAction, pending] = useActionState(action, initialFormState);
    //  ^-- Client Action
    console.log(state);

    return (
        <div className="flex items-center justify-center min-h-screen bg-gray-100">
            <div className="w-full max-w-sm p-6 bg-white rounded-lg shadow-md">
                <h2 className="text-2xl font-semibold text-center text-gray-700 mb-4">
                    Use Action State
                </h2>

                <form action={formAction} className="space-y-4">
                    <div>
                        <label
                            htmlFor="character"
                            className="block text-sm font-medium text-gray-700"
                        >
                            Character - {state}
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
                            // formAction={submitAction}
                            type="submit"
                            value="Login"
                            //disabled={pending}
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

