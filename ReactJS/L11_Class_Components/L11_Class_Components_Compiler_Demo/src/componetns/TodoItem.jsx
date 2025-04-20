function TodoItem({
    id,
    text,
    isCompleted,
    onToggle
}) {
    console.log(`${text} -> re-redners`);
    
    return (
        <li onClick={() => onToggle(id)} style={isCompleted ? { textDecoration: 'line-through' } : {}}>
            {text}
        </li>
    );
}

export default TodoItem;
