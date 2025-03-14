import { useEffect, useState } from "react";

export default function useFetch(url, defaultState = {}) {
    const [state, setState] = useState(defaultState);
    const [pending, setPending] = useState(true);

    useEffect(() => {
        setPending(true);

        fetch(url)
            .then(res => res.json())
            .then(result => {
                setState(Object.values(result));
                setPending(false);
            })
    }, [url]);

    return [pending, state];
}
 