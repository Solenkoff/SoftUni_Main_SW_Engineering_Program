import { useEffect, useRef, useState } from "react";

export default function UseRef() {
    const [count, setCount] = useState(0);
    const refMounted = useRef(false);

    useEffect(() => {
        if(refMounted.current){
            console.log(count, 'updated');
        }

        refMounted.current = true;
    }, [count]);

    return (

        <div className="flex items-center justify-center min-h-screen bg-gray-100">
            <div className="w-full max-w-sm p-6 bg-white rounded-lg shadow-md">
                <h2 className="text-2xl font-semibold text-center text-gray-700 mb-4">
                    Use Ref
                </h2>
                <div className="text-2xl font-semibold text-center text-gray-700 mb-4">{count}</div>

                <div className="w-full flex items-center justify-center space-y-4 ">
                    <button className={"w-18 px-4 py-2 font-semibold text-white transition bg-blue-600 rounded-md shadow-md"} onClick={() => setCount(s => s + 1)} >+</button>
                </div>

            </div>
        </div >
    );
}