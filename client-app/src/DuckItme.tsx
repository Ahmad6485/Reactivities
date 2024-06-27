import { Duck } from './Demo'

type Props={
    duck:Duck
}

export default function DuckItme({duck}: Props) {
    return (
        <div key={duck.name}>
            <span>{duck.name}</span>
            <button onClick={() => duck.makeSound(duck.name + ' quack')} >Make Sound</button>
        </div>
    )
}
