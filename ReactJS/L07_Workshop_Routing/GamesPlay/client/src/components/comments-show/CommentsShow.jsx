export default function CommentsShow({
    comments,
}) {
    return (
        <div className="details-comments">
            <h2>Comments:</h2>
            {comments.length > 0
                ?
                    <ul>
                        {comments.map(c =>
                            <li key={c._id} className="comment">
                                <p>{c.email}: {c.comment}</p>
                            </li>
                        )}
                    </ul>
                :
                    <p className="no-comment">No comments.</p>
            }
        </div>
    );
}